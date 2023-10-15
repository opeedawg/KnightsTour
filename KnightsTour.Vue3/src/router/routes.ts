/**
 * File:     routes.ts
 * Location: src\router\
 * The extended class for the @see router.
 * 
 * @author DXterity8 Version 8.6 <https://dxteritysolutions.com/>
 * Generated on January 21, 2023 at 7:35:06 AM
 */

// Imports
import { baseRoutes } from './routesBase';
import { RouteRecordRaw } from 'vue-router';

/** Routes definitions. */
export let routes: RouteRecordRaw[] = [];

// Add all the base routes in.
routes = routes.concat(baseRoutes);

export default routes;
