package com.example.DemoJPABuoi1.Model;

import javax.persistence.*;
import java.util.List;

@Table(name = "User")
@Entity
public class User {
    @javax.persistence.Id
    private int Id;
    @Column
    private String username;
    @Column
    private String password;
    @ManyToMany(fetch = FetchType.LAZY)
    @JoinTable(
            name = "users_roles",
            joinColumns = {@JoinColumn(name = "user_id", nullable = false)},
            inverseJoinColumns = {@JoinColumn(name = "role_id", nullable = false)}
    )
    List<Role> roles;
}
