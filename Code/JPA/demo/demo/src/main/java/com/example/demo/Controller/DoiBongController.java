package com.example.demo.Controller;

import com.example.demo.Model.DoiBong;
import com.example.demo.Repository.IDoiBongRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping(value = "/doiBong")
public class DoiBongController {
    @Autowired
    IDoiBongRepository doiBongRepository;

    @GetMapping(value = "/get")
    public List<DoiBong> LayDSDoiBong() {
        return doiBongRepository.findAll();
    }
}
