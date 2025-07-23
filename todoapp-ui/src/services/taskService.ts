import axios from 'axios';
import type { Task } from '../types/Task';

const API_URL = `${import.meta.env.VITE_API_BASE_URL}/Tasks`;

export const getAllTasks = async (): Promise<Task[]> => {
  const response = await axios.get<Task[]>(API_URL);
  return response.data;
};

export const createTask = async (task: Omit<Task, 'id' | 'isCompleted'>): Promise<Task> => {
  const response = await axios.post<Task>(API_URL, task);
  return response.data;
};

export const updateTask = async (id: number, updatedTask: Task): Promise<void> => {
  await axios.put(`${API_URL}/${id}`, updatedTask);
};

export const deleteTask = async (id: number): Promise<void> => {
  await axios.delete(`${API_URL}/${id}`);
};
