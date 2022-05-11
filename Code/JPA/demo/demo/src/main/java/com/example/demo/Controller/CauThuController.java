package com.example.demo.Controller;

import com.example.demo.Model.CauThu;
import com.example.demo.Repository.ICauThuRepository;
import com.google.gson.Gson;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.bind.annotation.*;

import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import javax.validation.ValidatorFactory;
import java.util.List;
import java.util.Set;

@RestController
@RequestMapping(value = "/cauThu")
@Transactional(rollbackFor = {Exception.class, Throwable.class})
public class CauThuController {
    @Autowired
    ICauThuRepository cauThuRepository;

    @GetMapping(value = "/get")
    public Page<CauThu> get(@RequestParam Integer page, Integer size) {
        Pageable pageable = PageRequest.of(page, size);
        System.out.println(new CauThu().getClass().getName());
        return cauThuRepository.findAll(pageable);
    }

    @PostMapping(value = "/post")
    public void add(@RequestBody String cauThu) {
        Gson gson = new Gson();
        CauThu newCauThu = gson.fromJson(cauThu, CauThu.class);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<CauThu>> violations = validator.validate(newCauThu);

        for (ConstraintViolation<CauThu> violation : violations) {
            System.out.println(violation.getMessage());
        }

        if (violations.size() == 0) {
            cauThuRepository.save(newCauThu);
        }
    }
}
