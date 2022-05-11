package com.example.demoCauThuJPA.Repository;

import com.example.demoCauThuJPA.Model.CauThu;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface CauThuRepository extends JpaRepository<CauThu, Integer> {
}
