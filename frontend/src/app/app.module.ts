import { AddStudentComponent } from './Pages/Student/Add-Student/Add-Student.component';
import { TableStudentComponent } from './Pages/Student/TableStudent/TableStudent.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {NgxPaginationModule} from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router'
import { SidebarComponent } from './Pages/Sidebar/Sidebar.component';

const appRoutes: Routes = [
  {path: 'tableStudent', component: TableStudentComponent},
  {path: 'addStudent', component: AddStudentComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    TableStudentComponent,
    AddStudentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgxPaginationModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
