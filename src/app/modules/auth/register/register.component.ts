import { Component, OnInit } from '@angular/core';
import { AbstractControl,FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public notAdmin : boolean = this.NotAdmin();
  public error : string | boolean = false;

  public registerForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    role: new FormControl('User', [Validators.required])
  });
  
  constructor(
    private authService: AuthService,
  ) { }

  // getters
  get email(): AbstractControl | null {
    return this.registerForm.get('email');
  }
  get password() : AbstractControl | null {
    return this.registerForm.get('password');
  }

  ngOnInit(): void {
  }
  
  public NotAdmin() : any{
     if(localStorage.getItem('Role') == 'User'){ 
        return true; 
      }
    return false;
  }

  public register(): void{
    this.error =  false;
    
    console.log("Register clicked");
    this.authService.createRegister(this.registerForm.value).subscribe(
      (response) =>{
      console.log(response);
      this.error = "Registered";
    },
    (error) =>{
      this.error = "Unable to register"; 
      console.error(error);
    }
    );
  }

}
