import { Authentication } from './authentication';
import { DXAuthenticatedUser } from './dxterity';

let instance: Authorization | null;

// These are important global settings - please make sure they are set appropriately!
const useRoleAuthentication = false;
const usePermissionAuthentication = false;

/**
 * Class: Authorization
 *
 * - Authorization controller.
 *
 * @implements {hasRole} Returns true if the user has the specified role.
 * @implements {hasRoles} Returns true if the user has all the specified roles.
 * @implements {hasPermission} Returns true if the user has the specified permission.
 * @implements {hasPermissions} Returns true if the user has all the specified permissions.
 * @implements {hasRoleAndPermission} Returns true if the user has the specified role and the specified permission.
 * @implements {hasRoleAndPermissions} Returns true if the user has the specified role and all the specified permissions.
 * @implements {hasRolesAndPermission} Returns true if the user has the specified permission and all the specified roles.
 * @implements {hasRolesAndPermissions} Returns true if the user has all the specified roles and all the specified permissions.
 */
class Authorization {
  constructor() {
    if (!instance) {
      instance = this;
    }
  }
  /**
   * Function [hasRole]:
   * - Determines if the authenticated user has the role.
   * @param {string} role The name of the role.
   */
  hasRole(role: string): boolean {
    const authentication: Authentication = new Authentication();

    if (authentication.isAuthenticated()) {
      if (!useRoleAuthentication) return true;
      authentication
        .getCurrentUser()
        .then(function (result: DXAuthenticatedUser | null) {
          if (result != null) {
            result.roles.forEach((roleName: string) => {
              if (roleName == role) {
                return true;
              }
            });
          }
        });

      // No role was found
      return false;
    } else {
      return false;
    }
  }
  /**
   * Function [hasRoles]:
   * - Determines if the authenticated user has all the roles.
   * @param {string[]} roles A list of roles the user must be a part of.
   */
  hasRoles(roles: string[]): boolean {
    const self = this;
    roles.forEach(function (role: string) {
      if (!self.hasRole(role)) {
        return false;
      }
    });

    return true;
  }
  /**
   * Function [hasPermission]:
   * - Determines if the authenticated user has the role.
   * @param {string} permission The name of the permission.
   */
  hasPermission(permission: string): boolean {
    const authentication: Authentication = new Authentication();

    if (authentication.isAuthenticated()) {
      if (!usePermissionAuthentication) return true;
      authentication
        .getCurrentUser()
        .then(function (result: DXAuthenticatedUser | null) {
          if (result != null) {
            result.permissions.forEach((permissionName: string) => {
              if (permissionName == permission) {
                return true;
              }
            });
          }
        });

      // No permission was found
      return false;
    } else {
      return false;
    }
  }
  /**
   * Function [hasPermissions]:
   * - Determines if the authenticated user has all the permissions.
   * @param {string[]} permissions A list of permissions the user must be a part of.
   */
  hasPermissions(permissions: string[]): boolean {
    const self = this;
    permissions.forEach(function (permission: string) {
      if (!self.hasPermission(permission)) {
        return false;
      }
    });

    return true;
  }
  /**
   * Function [hasRoleAndPermission]:
   * - Determines if the authenticated user has the permission and role.
   * @param {string} role The name of the role.
   * @param {string} permission The name of the permission.
   */
  hasRoleAndPermission(role: string, permission: string) {
    return this.hasRole(role) && this.hasPermission(permission);
  }
  /**
   * Function [hasRoleAndPermissions]:
   * - Determines if the authenticated user has all the permissions and role.
   * @param {string} role The name of the role.
   * @param {string[]} permissions A list of permissions the user must be a part of.
   */
  hasRoleAndPermissions(role: string, permissions: string[]) {
    return this.hasRole(role) && this.hasPermissions(permissions);
  }
  /**
   * Function [hasRolesAndPermission]:
   * - Determines if the authenticated user has all the roles and permission.
   * @param {string[]} roles A list of roles the user must be a part of.
   * @param {string} permission The name of the permission.
   */
  hasRolesAndPermission(roles: string[], permission: string) {
    return this.hasRoles(roles) && this.hasPermission(permission);
  }
  /**
   * Function [hasRolesAndPermissions]:
   * - Determines if the authenticated user has all the roles and all the permissions.
   * @param {string[]} roles A list of roles the user must be a part of.
   * @param {string[]} permissions A list of permissions the user must be a part of.
   */
  hasRolesAndPermissions(roles: string[], permissions: string[]) {
    return this.hasRoles(roles) && this.hasPermissions(permissions);
  }
}

export const _Authorization: Authorization = new Authorization();

const AuthorizationInstance = Object.freeze(new Authorization());

export default AuthorizationInstance;
