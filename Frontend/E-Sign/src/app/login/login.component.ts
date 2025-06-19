import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { LoginService } from './Service/login.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  imports: [FormsModule,ReactiveFormsModule,CommonModule,RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{

   loginForm!: FormGroup;
   loginServ = inject(LoginService)
   errorMessage!:string
   constructor(private route:ActivatedRoute,private router:Router,private toastr:ToastrService){}
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('',[Validators.required,Validators.minLength(8)])
    });
  }

  onSubmit(): void {
    if (this.loginForm.valid) {
      this.loginServ.loginUser(this.loginForm.value).subscribe({
          next:(i) => {
            this.loginServ.saveToken(i.token);
            this.router.navigate(["agreements"]);
          },
          error:(err) => {
            this.showError();
          }
      })
    }
  }

  showError(){
    this.toastr.error("Invalid credentials")
  }
}
