import React, { useState } from 'react';

interface TaskFormProps {
  onAdd: (description: string, deadline: string) => void;
  onSearch: (text: string) => void;
}

const TaskForm: React.FC<TaskFormProps> = ({ onAdd, onSearch }) => {
  const [description, setDescription] = useState('');
  const [deadline, setDeadline] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (description.trim().length <= 10) {
      alert('Description must be longer than 10 characters');
      return;
    }

    if (!deadline) {
      alert('Deadline is required');
      return;
    }

    onAdd(description.trim(), deadline);
    setDescription('');
    setDeadline('');
  };

  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setDescription(e.target.value);
    onSearch(e.target.value);
  };

  return (
    <form onSubmit={handleSubmit} className="task-form">
      <input
        type="text"
        placeholder="What needs to be done?"
        value={description}
        onChange={handleSearchChange}
      />
      <input
        type="date"
        value={deadline}
        onChange={(e) => setDeadline(e.target.value)}
      />
      <button type="submit">➕</button>
    </form>
  );
};

export default TaskForm;
