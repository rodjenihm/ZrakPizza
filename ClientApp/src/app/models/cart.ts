import { ProductVariant } from './product.variant';

export interface Cart {

  id: string;
  itemsCount: number;
  itemsTotalPrice: number;
  items: ProductVariant[];
}
