import { MaterialDesignIcon, SystemColor } from './global';
import { IEntitySettings } from './interfaces';
import pluralize from 'pluralize';

export class MenuSection {
  label: string;
  description: string;
  icon: MaterialDesignIcon;
  iconColor: SystemColor;
  nodes: MenuNode[];

  constructor(
    label: string,
    description?: string,
    icon?: MaterialDesignIcon,
    iconColor?: SystemColor
  ) {
    this.label = label;
    this.description = '';
    if (description != null) {
      this.description = description;
    }
    this.icon = MaterialDesignIcon.NONE;
    if (icon != null) {
      this.icon = icon;
    }
    this.iconColor = SystemColor.Primary;
    if (iconColor != null) {
      this.iconColor = iconColor;
    }
    this.nodes = [] as MenuNode[];
  }
}

export class MenuSectionFromSettings extends MenuSection {
  settings: IEntitySettings;

  constructor(settings: IEntitySettings, iconColor?: SystemColor) {
    super(
      settings.label,
      settings.label + ' management',
      settings.icon,
      iconColor
    );
    this.settings = settings;

    this.nodes.push(
      new MenuNode(
        this,
        'List',
        { name: settings.className + 'List' },
        'List and search ' + pluralize(settings.label),
        MaterialDesignIcon.List
      )
    );
    this.nodes.push(
      new MenuNode(
        this,
        'Add',
        { name: settings.className + 'Insert' },
        'Add a new ' + settings.label,
        MaterialDesignIcon.Add
      )
    );
  }
}

export class MenuNode extends MenuSection {
  section: MenuSection;
  route: any;
  id: string;

  constructor(
    section: MenuSection,
    label: string,
    route: any,
    description?: string,
    icon?: MaterialDesignIcon,
    iconColor?: SystemColor
  ) {
    super(label, description, icon, iconColor);
    this.section = section;
    this.route = route;
    this.id = this.section.label + '_' + this.label;
  }
}
