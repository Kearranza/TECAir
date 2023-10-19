package com.example.tecair_app.db;

public class Client {
    String username;
    String name;
    String lName1;
    String lName2;
    String email;
    Integer phone;
    Integer miles;

    Boolean isActive;

    //constuctor


    public Client(String username, String name, String lName1, String lName2, String email, Integer phone, Integer miles, Boolean isActive) {
        this.username = username;
        this.name = name;
        this.lName1 = lName1;
        this.lName2 = lName2;
        this.email = email;
        this.phone = phone;
        this.miles = miles;
        this.isActive = isActive;
    }

    public Client() {
    }

    //Getters y Setters
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getlName1() {
        return lName1;
    }

    public void setlName1(String lName1) {
        this.lName1 = lName1;
    }

    public String getlName2() {
        return lName2;
    }

    public void setlName2(String lName2) {
        this.lName2 = lName2;
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

    public Integer getMiles() {
        return miles;
    }

    public void setMiles(Integer miles) {
        this.miles = miles;
    }
    //to string

    public Boolean getIsActive(){return isActive;}
    public void setIsActive(Boolean isActive){this.isActive = isActive;}
}

