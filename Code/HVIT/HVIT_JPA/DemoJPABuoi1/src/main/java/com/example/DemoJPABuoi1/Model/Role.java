package com.example.DemoJPABuoi1.Model;

import javax.persistence.*;
import java.util.List;

@Table(name = "Role")
@Entity
public class Role {
    @javax.persistence.Id
    private int Id;
    @Column
    private String username;
    @ManyToMany(mappedBy = "roles")
    List<User> users;
}
