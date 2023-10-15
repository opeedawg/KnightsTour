import { DXAuthenticatedUser } from './dxterity';
import { Cookies } from 'quasar';
import { UtilityInstance } from './global';

/**
 * Class: Authentication
 *
 * - Authentication controller.
 *
 * @implements {getCurrentUser} Returns the current authenticated user or null if they are not authenticated.
 * @implements {isAuthenticated} Returns true if the user is authenticated.
 * @implements {refresh} Forces a complete refresh of all user authenticateion and authorization details.
 */
export class Authentication {
  cookieName: string;

  constructor() {
    this.cookieName = 'currentUser';
  }

  /**
   * Function [getCurrentUser]:
   * - Returns the authenticated user, or null if not authenticated.
   * @returns {DXAuthenticatedUser} The authenticated user.
   */
  async getCurrentUser(): Promise<DXAuthenticatedUser | null> {
    let currentUser = new DXAuthenticatedUser();
    if (!Cookies.has(this.cookieName)) {
      try {
        // Obiously testing code - implement as your application requries, example below.
        const authenticatedUser = new DXAuthenticatedUser();
        authenticatedUser.firstName = 'John';
        authenticatedUser.lastName = 'Tester';
        Cookies.set(this.cookieName, JSON.stringify(authenticatedUser), {
          secure: true,
        });
        const result = authenticatedUser;

        // const store = new EntitiesEmployeeStore();
        // const result = await store
        //   .getUserInformation()
        //   .then((response: DXResponse): DXAuthenticatedUser => {
        //     if (response.isValid) {
        //       const authenticatedUser =
        //         response.dataObject as DXAuthenticatedUser;
        //       Cookies.set(this.cookieName, JSON.stringify(authenticatedUser), {
        //         secure: true,
        //       });

        //       return authenticatedUser;
        //     } else {
        //       UtilityInstance.Unauthorized();

        //       // Throw the error message returned.
        //       throw response.messages[0].content;
        //     }
        //   });

        currentUser = result;
      } catch {
        UtilityInstance.SystemError();
      }
    } else {
      const currentUserCookie: any = Cookies.get(this.cookieName);

      if (currentUserCookie != null) {
        currentUser = currentUserCookie;
      } else {
        UtilityInstance.Unauthorized();
      }
    }

    return currentUser;
  }

  /**
   * Function [isAuthenticated]:
   * - Returns the whether or not the current user is authenticated.
   * @returns {boolean} Is the current user authenticated or not.
   */
  isAuthenticated(): boolean {
    return this.getCurrentUser() != null;
  }

  /**
   * Function [refresh]:
   * - Forces the authentication and authorization information to refresh from the server.
   */
  refresh(): void {
    Cookies.remove(this.cookieName);
  }
}
