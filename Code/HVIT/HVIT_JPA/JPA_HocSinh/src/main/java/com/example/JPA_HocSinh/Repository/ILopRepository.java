package com.example.JPA_HocSinh.Repository;

import com.example.JPA_HocSinh.Model.Lop;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ILopRepository extends JpaRepository<Lop,Integer> {
}
