package com.example.demo.Repository;

import com.example.demo.Model.DoiBong;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IDoiBongRepository extends JpaRepository<DoiBong, Integer> {
}
