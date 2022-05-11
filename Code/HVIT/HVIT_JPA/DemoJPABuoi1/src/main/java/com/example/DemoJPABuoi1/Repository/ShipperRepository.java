package com.example.DemoJPABuoi1.Repository;

import com.example.DemoJPABuoi1.Model.Shipper;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ShipperRepository extends JpaRepository<Shipper, Integer> {
}
