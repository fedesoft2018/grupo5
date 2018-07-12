import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (localStorage.getItem('currentUser')) {
            // ha iniciado sesión así que devuelve verdadero
            return true;
        }

      // no ha iniciado sesión así que redirigir a la página de inicio de sesión con la URL de retorno
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
