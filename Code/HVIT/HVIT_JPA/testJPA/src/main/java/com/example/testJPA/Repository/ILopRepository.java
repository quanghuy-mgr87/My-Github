package com.example.testJPA.Repository;

import com.example.testJPA.Model.Lop;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ILopRepository extends JpaRepository<Lop,Integer> {
}
