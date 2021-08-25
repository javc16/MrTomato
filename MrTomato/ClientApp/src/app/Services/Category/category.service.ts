import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryDTO } from 'src/app/Models/CategoryDTO';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private url:string;
  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) 
  {
    this.url = baseUrl+ 'api/category';
  }

  getData(): Observable<CategoryDTO[]> {
    return this.http.get<CategoryDTO[]>(this.url);
  }
}
