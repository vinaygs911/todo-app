import React, { useState, useEffect } from 'react';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import type { Task } from '../types/Task';
import {
  getAllTasks,
  createTask,
  updateTask,
  deleteTask
} from '../services/taskService';

import TaskForm from '../componenets/TaskForm';
import TaskTable from '../componenets/TaskTable';

const TaskPage: React.FC = () => {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [filter, setFilter] = useState<'all' | 'active' | 'completed'>('all');
  const [searchTerm, setSearchTerm] = useState('');

  const fetchTasks = async () => {
    try {
      const fetchedTasks = await getAllTasks();
      setTasks(fetchedTasks);
    } catch {
      toast.error('Error fetching tasks');
    }
  };

  useEffect(() => {
    fetchTasks();
  }, []);

  const handleAdd = async (description: string, deadline: string) => {
    const now = new Date().setHours(0, 0, 0, 0);
    const deadlineDate = new Date(deadline).setHours(0, 0, 0, 0);

    if (deadlineDate <= now) {
      toast.error('Deadline must be a future date');
      return;
    }

    try {
      await createTask({ description, deadline });
      toast.success('Task added');
      await fetchTasks();
    } catch (error: any) {
      toast.error(error?.response?.data?.detail || 'Failed to create task');
    }
  };

  const handleDone = async (id: number) => {
    const task = tasks.find(t => t.id === id);
    if (!task) return;

    const deadlineDate = task.deadline ? new Date(task.deadline).setHours(0, 0, 0, 0) : null;
    const today = new Date().setHours(0, 0, 0, 0);

    if (deadlineDate && deadlineDate <= today) {
      toast.error('Cannot complete task with past or today\'s deadline. Update the deadline first.');
      return;
    }

    try {
      await updateTask(id, { ...task, isCompleted: !task.isCompleted });
      toast.success('Task updated');
      await fetchTasks();
    } catch (error: any) {
      toast.error(error?.response?.data?.detail || 'Failed to update task');
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await deleteTask(id);
      toast.success('Task deleted');
      await fetchTasks();
    } catch {
      toast.error('Failed to delete task');
    }
  };

  const filteredTasks = tasks
    .filter(t => t.description.toLowerCase().includes(searchTerm.toLowerCase()))
    .filter(t =>
      filter === 'active' ? !t.isCompleted :
      filter === 'completed' ? t.isCompleted : true
    );

  return (
    <div className="container">
      <ToastContainer />
      <h1>ToDo</h1>
      <TaskForm onAdd={handleAdd} onSearch={setSearchTerm} />
      <TaskTable
        tasks={filteredTasks}
        onDone={handleDone}
        onDelete={handleDelete}
        onFilter={setFilter}
        currentFilter={filter}
      />
    </div>
  );
};

export default TaskPage;
