package com.example.tecair_app.db;

public class studentClient extends Client{
    String university;
    Integer carnet;

    public studentClient(String username, String name, String lName1, String lName2, String email, String phone, Integer miles, String university, Integer carnet, Boolean isActive) {
        super(username, name, lName1, lName2, email, phone, miles, isActive);
        this.university = university;
        this.carnet = carnet;
    }

    public String getUniversity() {
        return university;
    }

    public void setUniversity(String university) {
        this.university = university;
    }

    public Integer getCarnet() {
        return carnet;
    }

    public void setCarnet(Integer carnet) {
        this.carnet = carnet;
    }

    @Override
    public String toString() {
        return "studentClient{" +
                "university='" + university + '\'' +
                ", carnet='" + carnet + '\'' +
                ", username='" + username + '\'' +
                ", name='" + name + '\'' +
                ", lName1='" + lName1 + '\'' +
                ", lName2='" + lName2 + '\'' +
                ", email='" + email + '\'' +
                ", phone=" + phone +
                ", miles=" + miles +
                '}';
    }
}

