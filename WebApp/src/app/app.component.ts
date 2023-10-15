import { Component } from '@angular/core';
import { GetAPIService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'WebApp';
  test:any[] = [];

  constructor (private getAPI: GetAPIService){ }

  GetTestc(){
    this.getAPI.getDataeTest("chesto").subscribe(data => {
      this.test = data;
      console.log(this.test)
    })
  }

  GetTest(){
    this.getAPI.getDataTest().subscribe(data => {
      this.test = data;
      console.log(this.test)
    })
  }
}
