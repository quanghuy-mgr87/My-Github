package com.example.DemoJPABuoi1.Model;

import javax.persistence.*;
import java.util.List;

@Table(name = "address")
@Entity
public class Address {
    @javax.persistence.Id
    @GeneratedValue //giup tu dong tang
    private int Id;
    @Column
    private String city;
    @Column
    private String province;

    @OneToMany(mappedBy = "address", cascade = CascadeType.ALL)
    // Quan hệ 1-n với đối tượng ở dưới (Person) (1 địa điểm có nhiều người ở)
    // MapopedBy trỏ tới tên biến Address ở trong Person.
    private List<Person> personList;
}
