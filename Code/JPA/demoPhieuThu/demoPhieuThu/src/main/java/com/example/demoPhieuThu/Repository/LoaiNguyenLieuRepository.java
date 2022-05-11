package com.example.demoPhieuThu.Repository;

import com.example.demoPhieuThu.Model.LoaiNguyenLieu;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface LoaiNguyenLieuRepository extends JpaRepository<LoaiNguyenLieu, Integer> {
}
