package com.example.tecair_app.register;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.example.tecair_app.db.dataBaseHelper;
import com.example.tecair_app.db.studentClient;
import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;

public class studentRegister extends AppCompatActivity {
    TextView carnet, Universidad, Cedula;
    dataBaseHelper DBhelper = new dataBaseHelper(studentRegister.this);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student_register);

        carnet = findViewById(R.id.Carnet);
        Universidad = findViewById(R.id.Universidad);
        Cedula = findViewById(R.id.Cedula);
    }
    public void onClickBack(View view) {
        Intent intent = new Intent(this, registerAdmin.class);
        startActivity(intent);
    }

    public void onClickRegister(View view) {
        String ssn = carnet.getText().toString();
        String college = Universidad.getText().toString();
        String cedula = Cedula.getText().toString();
        if(ssn.isEmpty()){
            carnet.setError("Este campo no puede estar vacío");
            return;
        }
        if(college.isEmpty()){
            Universidad.setError("Este campo no puede estar vacio");
            return;
        }
        if(cedula.isEmpty()){
            Cedula.setError("Este campo no puede estar vacio");
            return;
        }
            studentClient client = new studentClient(college , Integer.valueOf(ssn), Integer.valueOf(cedula), 0);
            DBhelper.addOneStudent(client);
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);

    }
}