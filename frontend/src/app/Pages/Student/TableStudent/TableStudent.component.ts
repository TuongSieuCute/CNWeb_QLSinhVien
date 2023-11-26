import { Component, OnInit } from '@angular/core';
import { QuanLyService } from 'src/app/Services/QuanLy.service';
import { SinhVien } from 'src/app/Models/SinhVien';
import { Router } from '@angular/router';

searchQuery: HTMLInputElement;

@Component({
  selector: 'app-TableStudent',
  templateUrl: './TableStudent.component.html',
  styleUrls: ['./TableStudent.component.css']
})
export class TableStudentComponent implements OnInit {
  SinhVienList: SinhVien[] = [];
  currentPage: number = 1; 

  constructor(public QuanLyService: QuanLyService, private router: Router) {}

  ngOnInit(): void {
    this.loadSinhVienList(); 
  }

  loadSinhVienList() {
    this.QuanLyService.getAllData().subscribe({
      next: (list) => {
        this.SinhVienList = list.$values;
      },
      error: (error) => {
        console.error('Lỗi khi tải danh sách sinh viên', error);
      }
    });
  }

  editSinhVien(id: any) {
    // Navigate to the "edit-student" page with the student's ID
    this.router.navigate(['/edit-student', id]);
  }

  deleteSinhVien(id: any) {
      this.QuanLyService.delete(id).subscribe({
        next: (response) => {
          alert('Xoá thành công');
          this.loadSinhVienList();
        },
        error: (error) => {
          console.error('Lỗi khi xóa sinh viên', error);
        }
      });
    
  }

  searchByHoTen(hoten: string) {
    if (hoten) {
      this.QuanLyService.search(hoten).subscribe({
        next: (list) => {
          this.SinhVienList = list.$values;
        },
        error: (error) => {
          console.error('Lỗi khi tải danh sách sinh viên', error);
        }
      });
    } else {
      // If the search query is empty, load the full list of students.
      this.loadSinhVienList();
    }
  }
}
