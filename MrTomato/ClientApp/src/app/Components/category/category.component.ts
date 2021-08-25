import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryDTO } from 'src/app/Models/CategoryDTO';
import { CategoryService } from 'src/app/Services/Category/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  @Output('statusSlectedChange') statusSelectedChange: EventEmitter<any> = new EventEmitter(); 
  data!: CategoryDTO[];  
  displayedColumns: string[] = ['id','name','description','action'];
  
  constructor(private _categoryService: CategoryService,private router: Router,) { }

  ngOnInit() {
    this._categoryService.getData().subscribe((res: any[])=>{
      this.data= res;
      console.log(this.data)       
    })
  
  }
}
