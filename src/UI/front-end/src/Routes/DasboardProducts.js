import React, { useState, useEffect } from 'react';
import './DashboardProducts.css';

function DashboardProducts() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10); // Adjust the page size as needed
  const [totalPages, setTotalPages] = useState(0);

  useEffect(() => {
    fetchProducts();
  }, [page]); // Fetch products when the page changes

  const fetchProducts = async () => {
    setLoading(true);
    try {
      const response = await fetch(`https://localhost:44300/api/Product`);
      if (response.ok) {
        const data = await response.json();
        console.log('Fetched products:', data);
        setProducts(data || []);
      } else {
        console.error('Failed to fetch products');
      }
    } catch (error) {
      console.error('Error fetching products:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="dashboardProducts">
      <h2>Dashboard Products</h2>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <div>
          {products.map(product => (
            <div key={product.id} className="productItem">
              <p>Name: {product.name}</p>
              <p>Description: {product.description}</p>
              <p>Price: ${product.price}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

export default DashboardProducts;
