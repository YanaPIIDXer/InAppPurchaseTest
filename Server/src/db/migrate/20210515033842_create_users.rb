class CreateUsers < ActiveRecord::Migration[5.2]
  def change
    create_table :users do |t|
      t.string :name, unique: true
      t.integer :gold, not_null: true, default: 0

      t.timestamps
    end
  end
end
