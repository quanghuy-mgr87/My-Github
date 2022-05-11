package com.example.JPA_HocSinh.Controller;

import com.example.JPA_HocSinh.Model.HocSinh;
import com.example.JPA_HocSinh.Model.Lop;
import com.example.JPA_HocSinh.Repository.IHocSinhRepository;
import com.example.JPA_HocSinh.Repository.ILopRepository;
import com.google.gson.Gson;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import javax.validation.ValidatorFactory;
import java.util.List;
import java.util.Set;
import java.util.stream.Collector;
import java.util.stream.Collectors;
import java.util.stream.Stream;

@RestController
@RequestMapping(value = "/lop")
public class LopController {
    @Autowired
    private ILopRepository lopRepository;
    @Autowired
    private IHocSinhRepository hocSinhRepository;

    @GetMapping(value = "/")
    public List<Lop> HienThiDanhSachLop() {
        return lopRepository.findAll();
    }

    @PostMapping(value = "/themlop")
    public void ThemLop(@RequestBody String lop) {
        Gson gson = new Gson();
        Lop newLop = gson.fromJson(lop, Lop.class);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<Lop>> violations = validator.validate(newLop);
        for (ConstraintViolation<Lop> violation : violations) {
            System.out.println(violation.getMessage());
        }

        if (violations.size() == 0) {
//            newLop.setSiSo(hocSinhRepository.findAll().stream().filter(x -> x.getLop().getId() == newLop.getId()).collect(Collectors.toList()).size());
            newLop.setSiSo(lopRepository.findById(newLop.getId()).get().getHocSinhList().size());
            lopRepository.save(newLop);
        }
    }

    @PutMapping(value = "/sualop")
    public void SuaLop(@RequestBody String lop) {
        Gson gson = new Gson();
        Lop newLop = gson.fromJson(lop, Lop.class);
        Lop currentLop = lopRepository.findById(newLop.getId()).get();
        currentLop.setTenLop(newLop.getTenLop());

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<Lop>> violations = validator.validate(currentLop);
        for (ConstraintViolation<Lop> violation : violations) {
            System.out.println(violation.getMessage());
        }

        if (violations.size() == 0) {
            lopRepository.save(currentLop);
        }
    }

    @DeleteMapping(value = "/xoalop")
    public void XoaLop(@RequestParam int lopId) {
        lopRepository.deleteById(lopId);
    }
}
