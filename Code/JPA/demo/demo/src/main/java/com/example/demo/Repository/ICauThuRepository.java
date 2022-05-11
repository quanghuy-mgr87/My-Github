package com.example.demo.Repository;

import com.example.demo.Model.CauThu;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface ICauThuRepository extends JpaRepository<CauThu, Integer> {
//    Page<CauThu> findAll(Pageable pageable);
}
