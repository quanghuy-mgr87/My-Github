package com.example.demoCauThuJPA.Model;

import javax.persistence.*;
import java.util.List;

@Entity
@Table(name = "DoiBong")
public class DoiBong {
    @javax.persistence.Id
    private int Id;
    @Column
    private String tenDoiBong;
    @OneToMany(mappedBy = "doiBong", cascade = CascadeType.ALL)
    private List<CauThu> cauThus;
}
