using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegratedAccountManagement.Persistence.PostgresExtensionsMaps;

public static class MapPostgreSqlExtensions
    {
        public static PropertyBuilder<Guid> MapUuid<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, Guid>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("uuid")
                .ValueGeneratedNever()
                .IsRequired();
        }

        public static PropertyBuilder<Guid?> MapUuid<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, Guid?>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .ValueGeneratedNever()
                .HasColumnType("uuid");
        }

        public static PropertyBuilder<string> MapVarchar<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, string>> exp,
            string columnName,
            int size,
            bool isRequired)
            where T : class
        {
            var b = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"varchar({size})");
            return isRequired ? b.IsRequired() : b;
        }

        public static PropertyBuilder<string> MapVarchar<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, string>> exp,
            string columnName,
            bool isRequired)
            where T : class
        {
            var b = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"varchar");
            return isRequired ? b.IsRequired() : b;
        }

        public static PropertyBuilder<Enum> MapEnumAsVarchar<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, Enum>> exp,
            string columnName,
            int size,
            bool isRequired)
            where T : class
        {
            var b = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"varchar({size})")
                .HasConversion<string>();
            return isRequired ? b.IsRequired() : b;
        }

        public static PropertyBuilder<string> MapText<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, string>> exp,
            string columnName,
            bool isRequired)
            where T : class
        {
            var b = builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("text");
            return isRequired ? b.IsRequired() : b;
        }

        public static PropertyBuilder<bool> MapBoolean<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, bool>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("boolean")
                .IsRequired();
        }

        public static PropertyBuilder<bool?> MapBoolean<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, bool?>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("boolean");
        }

        public static PropertyBuilder<int> MapInt<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, int>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("int")
                .IsRequired();
        }

        public static PropertyBuilder<int?> MapInt<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, int?>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("int");
        }

        public static PropertyBuilder<DateTime> MapTimestamp<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, DateTime>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("timestamp")
                .IsRequired();
        }

        public static PropertyBuilder<DateTime?> MapTimestamp<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, DateTime?>> exp,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType("timestamp");
        }

        public static PropertyBuilder<double> MapNumeric<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, double>> exp,
            int range,
            int precision,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"numeric({range},{precision})")
                .IsRequired();
        }

        public static PropertyBuilder<double?> MapNumeric<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, double?>> exp,
            int range,
            int precision,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"numeric({range},{precision})");
        }

        public static PropertyBuilder<decimal> MapNumeric<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, decimal>> exp,
            int range,
            int precision,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"numeric({range},{precision})")
                .IsRequired();
        }

        public static PropertyBuilder<decimal?> MapNumeric<T>(this EntityTypeBuilder<T> builder,
            Expression<Func<T, decimal?>> exp,
            int range,
            int precision,
            string columnName)
            where T : class
        {
            return builder.Property(exp)
                .HasColumnName(columnName)
                .HasColumnType($"numeric({range},{precision})");
        }
    }