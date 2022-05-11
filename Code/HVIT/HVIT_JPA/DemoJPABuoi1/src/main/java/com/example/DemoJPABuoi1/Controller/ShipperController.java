package com.example.DemoJPABuoi1.Controller;

import com.example.DemoJPABuoi1.Model.Shipper;
import com.example.DemoJPABuoi1.Repository.ShipperRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class ShipperController {
    @Autowired
    ShipperRepository shipperRepository;

    @GetMapping(value = "/shipper")
    public void CreateNewShipper(){
        Shipper shipper = new Shipper();
        shipper.setId(1);
        shipper.setName("Kha");
        shipper.setLevel(3);
        shipperRepository.save(shipper);

        Shipper shipper1 = new Shipper();
        shipper.setId(2);
        shipper.setName("Phuong");
        shipper.setLevel(10);
        shipperRepository.save(shipper1);

    }
}
