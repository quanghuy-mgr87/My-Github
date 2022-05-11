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
import java.util.stream.Collectors;

@RestController
@RequestMapping(value = "/hocsinh")
public class HocSinhController {
    @Autowired
    private IHocSinhRepository hocSinhRepository;
    @Autowired
    private ILopRepository lopRepository;

    @GetMapping(value = "/")
    public List<HocSinh> LayDanhSachHS() {
        return hocSinhRepository.findAll();
    }

    public boolean CapNhatSiSo(int lopId) {
        Lop lop = lopRepository.findById(lopId).get();
        //lay hoc sinh thuoc lopId, dem so luong hoc sinh lop do r cap nhat si so
//        List<HocSinh> hocSinhList = hocSinhRepository.findAll().stream().filter(x -> x.getLop().getId() == lopId).collect(Collectors.toList());
        List<HocSinh> hocSinhList = lopRepository.findById(lopId).get().getHocSinhList();
        lop.setSiSo(hocSinhList.size() + 1);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<Lop>> violations = validator.validate(lop);

        for (ConstraintViolation<Lop> violation : violations) {
            System.out.println(violation.getMessage());
        }

        if (violations.size() == 0) {
            lopRepository.save(lop);
            return true;
        }
        return false;
    }

    @PostMapping(value = "/themHs")
    public void ThemHocSinh(@RequestBody String hocSinh) {
        Gson gson = new Gson();
        HocSinh newHs = gson.fromJson(hocSinh, HocSinh.class);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<HocSinh>> violations = validator.validate(newHs);

        for (ConstraintViolation<HocSinh> violation : violations) {
            System.out.println(violation.getMessage());
        }

        if (violations.size() == 0 && CapNhatSiSo(newHs.getLop().getId()) == true) {
            hocSinhRepository.save(newHs);
        }
    }

    @PutMapping(value = "/suaHs")
    public void SuaHocSinh(@RequestBody String hocSinh) {
        Gson gson = new Gson();
        HocSinh newHs = gson.fromJson(hocSinh, HocSinh.class);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<HocSinh>> violations = validator.validate(newHs);

        var currentHs = hocSinhRepository.findById(newHs.getId()).get();
        currentHs.setHoTen(newHs.getHoTen());
        currentHs.setNamSinh(newHs.getNamSinh());
        currentHs.setQueQuan(newHs.getQueQuan());

        for (ConstraintViolation<HocSinh> violation : violations) {
            System.out.println(violation);
        }

        if (violations.size() == 0) {
            hocSinhRepository.save(currentHs);
        }
    }
}
