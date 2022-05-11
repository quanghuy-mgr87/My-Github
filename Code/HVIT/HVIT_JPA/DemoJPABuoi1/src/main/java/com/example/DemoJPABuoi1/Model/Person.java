package com.example.DemoJPABuoi1.Model;

import javax.persistence.*;

@Table(name = "Person")
@Entity
public class Person {
    @javax.persistence.Id
    @GeneratedValue
    private int Id;
    @Column
    private String name;

    @ManyToOne
    @JoinColumn(name = "address_id") // thông qua khóa ngoại address_id
    private Address address;
}
