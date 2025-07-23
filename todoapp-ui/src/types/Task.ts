export interface Task {
  id: number;
  description: string;
  isCompleted: boolean;
  deadline?: string;
}