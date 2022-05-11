package com.example.DemoJPABuoi1.Repository;

import com.example.DemoJPABuoi1.Model.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ProductRepository extends JpaRepository<Product, Integer> {

}
