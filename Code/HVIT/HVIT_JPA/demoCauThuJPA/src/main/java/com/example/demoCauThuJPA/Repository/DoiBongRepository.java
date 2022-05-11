package com.example.demoCauThuJPA.Repository;

import com.example.demoCauThuJPA.Model.DoiBong;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DoiBongRepository extends JpaRepository<DoiBong, Integer> {
}
