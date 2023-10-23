package com.example.tecair_app.db;

public class basicClient {
    String name;
    String lname1;
    String lname2;
    String email;
    Integer phone;
    Integer cedula;

    public basicClient(String name, String lname1, String lname2, String email, Integer phone, Integer cedula) {
        this.name = name;
        this.lname1 = lname1;
        this.lname2 = lname2;
        this.email = email;
        this.phone = phone;
        this.cedula = cedula;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLname1() {
        return lname1;
    }

    public void setLname1(String lname1) {
        this.lname1 = lname1;
    }

    public String getLname2() {
        return lname2;
    }

    public void setLname2(String lname2) {
        this.lname2 = lname2;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Integer getPhone() {
        return phone;
    }

    public void setPhone(Integer phone) {
        this.phone = phone;
    }

    public Integer getCedula() {return cedula;}

    @Override
    public String toString() {
        return "basicClient{" +
                "name='" + name + '\'' +
                ", lname1='" + lname1 + '\'' +
                ", lname2='" + lname2 + '\'' +
                ", email='" + email + '\'' +
                ", phone=" + phone +
                '}';
    }
}
