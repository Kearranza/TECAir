package com.example.tecair_app.db;

public class comonClient {
    Integer cedula;
    String password;

    public comonClient(Integer cedula, String password) {
        this.cedula = cedula;
        this.password = password;
    }

    public Integer getCedula() {
        return cedula;
    }

    public void setCedula(Integer cedula) {
        this.cedula = cedula;
    }

    public String getPassword() {
        return password;
    }

    @Override
    public String toString() {
        return "comonClient{" +
                "cedula=" + cedula +
                '}';
    }
}
