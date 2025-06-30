import { HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { LoginService } from "../login/Service/login.service";
import { inject } from "@angular/core";
import { Observable } from "rxjs";

export const authInterceptor:HttpInterceptorFn = (req:HttpRequest<unknown>,next:HttpHandlerFn): Observable<HttpEvent<unknown>> => {
    const authToken = inject(LoginService).getToken();
    if(authToken){
        const cloned = req.clone({
            headers:req.headers.append('X-Authentication-Token',authToken),
        });
        return next(cloned);
    }
    return next(req);
}