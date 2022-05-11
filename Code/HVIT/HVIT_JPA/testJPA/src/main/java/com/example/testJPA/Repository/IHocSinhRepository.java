package com.example.testJPA.Repository;

import com.example.testJPA.Model.HocSinh;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IHocSinhRepository extends JpaRepository<HocSinh,Integer> {
}
