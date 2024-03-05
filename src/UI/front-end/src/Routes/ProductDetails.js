import React, { useState } from 'react';
import './ProductDetails.css';

function ProductDetails() {
  const [productId, setProductId] = useState('');
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    try {
      const response = await fetch(`https://localhost:44300/api/Product?productId=${productId}`);
      if (response.ok) {
        const data = await response.json();
        setProduct(data);
      } else {
        console.error('Failed to fetch product details');
      }
    } catch (error) {
      console.error('Error fetching product details:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleRemove = async () => {
    if (!product || !product.id) return;
    try {
      const response = await fetch(`https://localhost:44300/api/Product/${product.id}`, {
        method: 'DELETE',
      });
      if (response.ok) {
        console.log('Product removed successfully');
        setProduct(null);
      } else {
        console.error('Failed to remove product');
      }
    } catch (error) {
      console.error('Error removing product:', error);
    }
  };

  return (
    <div className="productDetails">
      <h2>Product Details</h2>
      <form onSubmit={handleSubmit}>
        <label htmlFor="productId">Product ID:</label>
        <input
          type="text"
          id="productId"
          value={productId}
          onChange={(e) => setProductId(e.target.value)}
          required
        />
        <button type="submit" disabled={loading}>
          {loading ? 'Loading...' : 'Submit'}
        </button>
      </form>
      {product && (
        <div>
          <p>Name: {product.name}</p>
          <p>Description: {product.description}</p>
          <p>Price: ${product.price}</p>
          <button onClick={handleRemove}>Remove Product</button>
          {/* Add more product details as needed */}
        </div>
      )}
    </div>
  );
}

export default ProductDetails;
