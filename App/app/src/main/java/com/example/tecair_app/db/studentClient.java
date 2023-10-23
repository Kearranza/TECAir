package com.example.tecair_app.db;

public class studentClient{
    String university;
    Integer carnet;
    Integer cedula;
    Integer miles;


    public studentClient(String university, Integer carnet, Integer cedula, Integer miles) {
        this.university = university;
        this.carnet = carnet;
        this.cedula = cedula;
        this.miles = miles;
    }

    public String getUniversity() {
        return university;
    }

    public Integer getCarnet() {
        return carnet;
    }

    public Integer getCedula() {
        return cedula;
    }

    public Integer getMiles() {
        return miles;
    }

    @Override
    public String toString() {
        return "studentClient{" +
                "university='" + university + '\'' +
                ", carnet='" + carnet + '\'' +
                '}';
    }
}

