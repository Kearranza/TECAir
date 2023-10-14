import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetAPIService {

  //Urls para conectarse a la API
  private urlTestUrl = 'https://pokeapi.co/api/v2/pokemon/ditto';

  //Url para realizar consultas de un archivo en especifico 
  //private consutl:string = '';
  //private urlTestcUrl  = `https://pokeapi.co/api/v2/berry/?search=${this.consutl}`;

  //Constructor que crea un httpClient para poder realizar conecciones con la API
  constructor(private http: HttpClient) { }

  // Metodos de Post y Gets para la API
  getDataTest(): Observable<any> {
    return this.http.get<any>(this.urlTestUrl)
  }

  getDataeTest(i:string): Observable<any> {
    const urlTestcUrl  = `https://pokeapi.co/api/v2/berry/${i}`;
    return this.http.get<any>(urlTestcUrl)
  }

  postDataTest(data: any): Observable<any> {
    return this.http.post<any>(this.urlTestUrl, data);
  }

  updateDataTest(id: number, data: any): Observable<any> {
    const url = `https://pokeapi.co/api/v2/berry/${id}`
    return this.http.put(url, data);
  }

  eliminarRecurso(id: number): Observable<any> {
    const url = `${this.urlTestUrl}/${id}`;
    return this.http.delete(url);
  }
}
