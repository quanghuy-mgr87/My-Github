package com.example.JPA_HocSinh.Repository;

import com.example.JPA_HocSinh.Model.HocSinh;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IHocSinhRepository extends JpaRepository<HocSinh,Integer> {
}
