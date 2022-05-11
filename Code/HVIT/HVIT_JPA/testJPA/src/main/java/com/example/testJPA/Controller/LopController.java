package com.example.testJPA.Controller;

import com.example.testJPA.Model.Lop;
import com.example.testJPA.Repository.ILopRepository;
import com.google.gson.Gson;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

import javax.validation.ConstraintViolation;
import javax.validation.Validation;
import javax.validation.Validator;
import javax.validation.ValidatorFactory;
import java.util.List;
import java.util.Set;

@RestController
@RequestMapping(value = "/lop")
public class LopController {
    @Autowired
    ILopRepository lopRepository;

    @GetMapping(value = "/",produces = MediaType.APPLICATION_JSON_VALUE)
    public List<Lop> getClassList(){
        return lopRepository.findAll();
    }

    @PostMapping(value = "/addLop",produces = MediaType.APPLICATION_JSON_VALUE)
    public void addClass(@RequestBody String lop){
        Gson gson = new Gson();
        Lop newClass = gson.fromJson(lop, Lop.class);

        ValidatorFactory validatorFactory = Validation.buildDefaultValidatorFactory();
        Validator validator = validatorFactory.getValidator();

        Set<ConstraintViolation<Lop>> violations = validator.validate(newClass);
        for (ConstraintViolation<Lop> violation : violations) {
            System.out.println(violation.getMessage());
        }

        if(violations.size() == 0){
            lopRepository.save(newClass);
        }
    }
}
