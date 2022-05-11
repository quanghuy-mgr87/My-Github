package com.example.demoCauThuJPA.Controller;

import com.example.demoCauThuJPA.Model.CauThu;
import com.example.demoCauThuJPA.Repository.CauThuRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;
import com.google.gson.Gson;

import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import javax.validation.ValidatorFactory;
import java.util.List;
import java.util.Set;

@RestController
@RequestMapping(value = "/cauthu")
public class CauThuController {
    @Autowired
    CauThuRepository cauThuRepository;

    @PostMapping(value = "/add", produces = MediaType.APPLICATION_JSON_VALUE)
    public void add(@RequestBody String cauThu) {
        Gson gson = new Gson();
        CauThu cauThuMoi = gson.fromJson(cauThu, CauThu.class);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<CauThu>> violations = validator.validate(cauThuMoi);
        for (ConstraintViolation<CauThu> violation : violations) {
            System.out.printf(violation.getMessage());
        }

        if (violations.size() == 0) {
            cauThuRepository.save(cauThuMoi);
        }

        //return cauThuMoi;
    }

    @GetMapping(value = "/")
    public List<CauThu> getData(){
        return cauThuRepository.findAll();
    }
}
