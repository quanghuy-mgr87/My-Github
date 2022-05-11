package com.example.DemoJPABuoi1.Controller;

import com.example.DemoJPABuoi1.Model.Product;
import com.example.DemoJPABuoi1.Repository.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class ProductController {
    @Autowired
    ProductRepository productRepository;

    @GetMapping(value = "/home", produces = MediaType.APPLICATION_JSON_VALUE)

    public List<Product> home() {
        return productRepository.findAll();
    }
}
