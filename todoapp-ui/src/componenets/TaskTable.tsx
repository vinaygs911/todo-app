import React from 'react';
import type { Task } from '../types/Task';

interface Props {
  tasks: Task[];
  onDone: (id: number) => void;
  onDelete: (id: number) => void;
  onFilter: (status: 'all' | 'active' | 'completed') => void;
  currentFilter: string;
}

const TaskTable: React.FC<Props> = ({ tasks, onDone, onDelete, onFilter, currentFilter }) => {
  const remaining = tasks.filter(t => !t.isCompleted).length;

  return (
    <div className="task-table">
      <ul>
        {tasks.map(task => {
          const isOverdue =
            task.deadline &&
            new Date(task.deadline) < new Date(new Date().toDateString());

          return (
            <li
              key={task.id}
              className={`task-row ${task.isCompleted ? 'completed' : ''}`}
            >
              <input
                type="checkbox"
                checked={task.isCompleted}
                onChange={() => onDone(task.id)}
              />
              <div className="task-content">
                <span
                  className="task-desc"
                  style={{ color: isOverdue ? 'red' : 'inherit' }}
                >
                  {task.description}
                </span>
                {task.deadline && (
                  <span className="task-deadline">
                    ({task.deadline})
                  </span>
                )}
              </div>
              <button onClick={() => onDelete(task.id)}>❌</button>
            </li>
          );
        })}
      </ul>

      <div className="footer">
        <span>{remaining} items left</span>
        <div className="filters">
          <button className={currentFilter === 'all' ? 'selected' : ''} onClick={() => onFilter('all')}>All</button>
          <button className={currentFilter === 'active' ? 'selected' : ''} onClick={() => onFilter('active')}>Active</button>
          <button className={currentFilter === 'completed' ? 'selected' : ''} onClick={() => onFilter('completed')}>Completed</button>
        </div>
      </div>
    </div>
  );
};

export default TaskTable;
