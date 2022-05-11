package com.example.demoPhieuThu.Repository;

import com.example.demoPhieuThu.Model.NguyenLieu;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface NguyenLieuRepository extends JpaRepository<NguyenLieu, Integer> {
}
