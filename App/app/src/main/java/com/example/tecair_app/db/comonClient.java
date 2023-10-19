package com.example.tecair_app.db;

public class comonClient extends Client {
    Integer cedula;

    public comonClient(String username, String name, String lName1, String lName2, String email, String phone, Integer miles, Integer cedula, Boolean isActive) {
        super(username, name, lName1, lName2, email, phone, miles, isActive);
        this.cedula = cedula;
    }

    public Integer getCedula() {
        return cedula;
    }

    public void setCedula(Integer cedula) {
        this.cedula = cedula;
    }

    @Override
    public String toString() {
        return "comonClient{" +
                "cedula=" + cedula +
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
