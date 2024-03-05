import React, { useState } from 'react';
import './AddCustomer.css';

function AddCustomer() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [customerId, setCustomerId] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    try {
      const response = await fetch('https://localhost:44300/api/Customer', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ name, email }),
      });

      if (response.ok) {
        console.log('Customer added successfully');
        // Reset form fields after successful submission
        setName('');
        setEmail('');
      } else {
        console.error('Failed to add customer');
      }
    } catch (error) {
      console.error('Error adding customer:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleRemove = async () => {
    setLoading(true);
    try {
      const response = await fetch(`https://localhost:44300/api/Customer?customerId=${customerId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });
  
      if (response.ok) {
        console.log('Customer removed successfully');
      } else {
        console.error('Failed to remove customer');
      }
    } catch (error) {
      console.error('Error removing customer:', error);
    } finally {
      setLoading(false);
    }
  };
  

  return (
    <div className="customer">
      <h2>Add Customer</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="name">Name:</label>
          <input
            type="text"
            id="name"
            name="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div>
          <label htmlFor="email">Email: </label>
          <input
            type="email"
            id="email"
            name="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <button type="submit" disabled={loading}>
          {loading ? 'Submitting...' : 'Submit'}
        </button>
      </form>
      <div>
            <h2> Remove Customer</h2>
            <div>
        <label htmlFor="customerId">Customer ID:</label>
        <input
          type="text"
          id="customerId"
          name="customerId"
          value={customerId}
          onChange={(e) => setCustomerId(e.target.value)}
          required
        />
        <button onClick={handleRemove}>Remove Customer</button>
      </div>
        </div>

    </div>
  );
}

export default AddCustomer;
