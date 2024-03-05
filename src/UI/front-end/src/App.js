import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css';
import Home from './Routes/Home';
import AddCustomer from './Routes/AddCustomer'; // Import the AddCustomer component
import ProductDetails from './Routes/ProductDetails'; // Import the ProductDetails component
import DashboardProducts from './Routes/DasboardProducts';

function App() {
  return (
    <Router>
      <div className="App">
        <h1 className="title">ECOMMERCE STORE</h1>
        <nav>
          <ul className="nav-links">
            <li><Link to="/Home">Home</Link></li>
            <li><Link to="/add-customer">Add Customer</Link></li>
            <li><Link to="/product-details">Product Details</Link></li>
            <li><Link to="/basket-checkout">Basket & Checkout</Link></li>
            <li><Link to="/past-orders">Past Orders</Link></li>
            <li><Link to="/dashboard-products">Dashboard Of Products</Link></li>

          </ul>
        </nav>
        {/* Define routes */}
        <Routes>
          <Route path="/Home" element={<Home />} />
          <Route path="/add-customer" element={<AddCustomer />} />
          <Route path="/product-details" element={<ProductDetails />} />
          <Route path="/dashboard-products" element={<DashboardProducts />} />

          {/* Define other routes here */}
        </Routes>
      </div>
    </Router>
  );
}

export default App;
